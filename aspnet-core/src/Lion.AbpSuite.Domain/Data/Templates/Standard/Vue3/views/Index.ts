import { FormSchema } from '/@/components/Table';
import { BasicColumn } from '/@/components/Table';
import {
   {{ context.EntityModel.AggregateCodePluralized }}ServiceProxy,
    Delete{{ context.EntityModel.AggregateCode }}Input,
    Page{{ context.EntityModel.AggregateCode }}Input,
} from '/@/services/ServiceProxies';

// 分页表格{{ context.EntityModel.Description }} BasicColumn
export const tableColumns: BasicColumn[] = [
{{~ for prop in context.EntityModel.Properties ~}}
    {
    title: '{{prop.Description}}',
    dataIndex: '{{prop.CodeCamelCase}}',
    },    
{{~ end ~}}
];

// 分页查询{{ context.EntityModel.Description }} FormSchema
export const searchFormSchema: FormSchema[] = [];

// 创建{{ context.EntityModel.Description }} FormSchema
export const createFormSchema: FormSchema[] = [
{{~ for prop in context.EntityModel.Properties ~}}
  {
    field: '{{prop.CodeCamelCase}}',
    label: '{{prop.Description}}',
    component: "Input",
    required: {{prop.IsRequired}},
    colProps: { span: 18 }
  },
{{~ end ~}} 
];

// 编辑{{ context.EntityModel.Description }} FormSchema
export const updateFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: 'Id',
    component: "Input",
    ifShow: false,
    colProps: { span: 18 }
  },
{{~ for prop in context.EntityModel.Properties ~}}
  {
    field: '{{prop.CodeCamelCase}}',
    label: '{{prop.Description}}',
    component: "Input",
    required: {{prop.IsRequired}},
    colProps: { span: 18 }
  },
{{~ end ~}} 
];

/**
 * 分页查询{{ context.EntityModel.Description }}
 */
export async function pageAsync(params: Page{{ context.EntityModel.AggregateCode }}Input,
){
  const {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy = new {{ context.EntityModel.AggregateCodePluralized }}ServiceProxy();
  return {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy.page(params);
}

/**
 * 创建{{ context.EntityModel.Description }}
 */
export async function createAsync({ params }) {
  const {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy = new {{ context.EntityModel.AggregateCodePluralized }}ServiceProxy();
  await {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy.create(params);
}

/**
 * 更新{{ context.EntityModel.Description }}
 */
export async function updateAsync({ params }) {
  const {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy = new {{ context.EntityModel.AggregateCodePluralized }}ServiceProxy();
  await {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy.update(params);
}

/**
 * 删除{{ context.EntityModel.Description }}
 */
export async function deleteAsync({ id }) {
  const {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy = new {{ context.EntityModel.AggregateCodePluralized }}ServiceProxy();
  const request = new Delete{{ context.EntityModel.AggregateCode }}Input();
  request.id = id;
  await {{ context.EntityModel.AggregateCodeCamelCase }}ServiceProxy.delete(request);
}