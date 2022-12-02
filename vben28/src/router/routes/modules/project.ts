import type { AppRouteModule } from '/@/router/types';
import { LAYOUT } from '/@/router/constant';
const projects: AppRouteModule = {
  path: '/projects',
  name: 'Projects',
  component: LAYOUT,
  meta: {
    orderNo: 40,
    icon: 'ant-design:file-twotone',
    title: '项目管理',
  },
  children: [
    {
      path: 'page',
      name: 'Page',
      component: () => import('/@/views/projects/Project1.vue'),
      meta: {
        title: '项目',
        icon: 'ant-design:file-sync-outlined',
      },
    },
    {
      path: 'entityModel',
      name: 'EntityModel',
      component: () => import('/@/views/entityModels/EntityModel.vue'),
      meta: {
        title: '实体',
        icon: 'ant-design:skin-outlined',
        hideMenu: true,
      },
    },
  ],
};

export default projects;
