namespace Lion.AbpSuite.Extensions;

public class TreeManager : ISingletonDependency
{
    private List<TreeNode> treeNodes;

    private int maxLevel = 0;

    /// <summary>
    /// 去重
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public List<TreeNode> Distinct(List<TreeNode> list)
    {
        treeNodes = list;
        InitLevel(new TreeNode() { Title = "", Level = 0 }, list);
        var result = new List<TreeNode>();
        foreach (var item in treeNodes)
        {
            MegreNode(item, ref result);
        }

        return result;
    }


    /// <summary>
    /// 初始化数据 level深度节点，fullTitle完整标题路径，parentFullTitle父级标题
    /// </summary>
    private void InitLevel(TreeNode parentNode, List<TreeNode> list)
    {
        foreach (TreeNode node in list)
        {
            node.Level = parentNode.Level + 1;
            if (node.Level > maxLevel)
            {
                maxLevel = node.Level;
            }

            node.FullTitle = parentNode.FullTitle + node.Title;
            node.ParentFullTitle = parentNode.FullTitle;
            var chils = node.Children;
            InitLevel(node, chils);
        }
    }

    /// <summary>
    /// 合并节点
    /// </summary>
    private void MegreNode(TreeNode currentNode, ref List<TreeNode> result)
    {
        //找到同一深度下的节点
        var list = GetSameNode(this.treeNodes, currentNode.Level);
        var listGroup = list.GroupBy(t => t.FullTitle).ToList();
        //找出有重复的分组数据
        var listGroupDistinct = listGroup.Where(t => t.Count() > 1).ToList();
        //重复的数据
        var listDistinct = new List<TreeNode>();
        foreach (var item in listGroupDistinct)
        {
            var itemList = item.ToList();
            listDistinct.AddRange(itemList);
        }

        //先添加不重复的数据
        foreach (var item in list)
        {
            if (listDistinct.Where(t => t.FullTitle == item.FullTitle).Count() == 0)
            {
                var parentMegreNode = FindParentMegreNode(item, result);
                var addNode = new TreeNode()
                {
                    FullTitle = item.FullTitle,
                    Level = item.Level,
                    Title = item.Title,
                    ParentFullTitle = item.ParentFullTitle,
                    Content = item.Content,
                    Name = item.Name,
                    Description = item.Description,
                    Key = item.Key,
                    IsFolder = item.IsFolder,
                    Icon = item.Icon
                };

                //是否已经添加
                if (HasAddMegre(addNode, result))
                {
                    continue;
                }

                if (parentMegreNode == null)
                {
                    result.Add(addNode);
                }
                else
                {
                    parentMegreNode.Children.Add(addNode);
                }
            }
        }

        //再添加重复的数据
        foreach (var item in listGroupDistinct)
        {
            var first = item.First();
            var parentMegreNode = FindParentMegreNode(first, result);

            var addNode = new TreeNode()
            {
                FullTitle = first.FullTitle,
                Level = first.Level,
                Title = first.Title,
                ParentFullTitle = first.ParentFullTitle,
                Content = first.Content,
                Name = first.Name,
                Description = first.Description,
                Key = first.Key,
                IsFolder = first.IsFolder,
                Icon = first.Icon
            };

            //是否已经添加
            if (HasAddMegre(addNode, result))
            {
                continue;
            }

            if (parentMegreNode == null)
            {
                result.Add(addNode);
            }
            else
            {
                parentMegreNode.Children.Add(addNode);
            }
        }

        var chils = currentNode.Children;
        if (chils == null)
        {
            return;
        }

        foreach (var item in chils)
        {
            this.MegreNode(item, ref result);
        }
    }

    //是否已添加合并数据，添加过的不再添加进去
    public bool HasAddMegre(TreeNode addNode, List<TreeNode> listMegre)
    {
        bool result = false;
        foreach (var item in listMegre)
        {
            if (item.FullTitle == addNode?.FullTitle && item.Level == addNode?.Level)
            {
                result = true;
                break;
            }

            var chils = item.Children;
            result = HasAddMegre(addNode, chils);
            if (result)
            {
                return result;
            }
        }

        return result;
    }

    //寻找父级，如果找到父级，追加到父级的children中
    public TreeNode FindParentMegreNode(TreeNode currentNode, List<TreeNode> listMegre)
    {
        if (currentNode == null || string.IsNullOrEmpty(currentNode?.ParentFullTitle))
        {
            return null;
        }

        TreeNode parent = null;
        foreach (var item in listMegre)
        {
            if (item.FullTitle == currentNode?.ParentFullTitle && item.Level + 1 == currentNode?.Level)
            {
                parent = item;
                break;
            }

            var chils = item.Children;
            parent = FindParentMegreNode(currentNode, chils);
            if (parent != null)
            {
                return parent;
            }
        }

        return parent;
    }


    /// <summary>
    /// 获取同一深度下的节点
    /// </summary>
    /// <param name="list"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public List<TreeNode> GetSameNode(List<TreeNode> list, int level)
    {
        List<TreeNode> listSame = new List<TreeNode>();
        foreach (TreeNode node in list)
        {
            if (node.Level == level)
            {
                listSame.Add(node);
            }
            else
            {
                var chils = node.Children;
                listSame.AddRange(GetSameNode(chils, level));
            }
        }

        return listSame;
    }
}