import type { AppRouteModule } from '/@/router/types';
import { LAYOUT } from '/@/router/constant';
const template: AppRouteModule = {
  path: '/templates',
  name: 'Templates',
  component: LAYOUT,
  meta: {
    orderNo: 40,
    icon: 'ant-design:file-twotone',
    title: '模板管理',
  },
  children: [
    {
      path: 'group',
      name: 'Group',
      component: () => import('/@/views/templates/Template.vue'),
      meta: {
        title: '模板组',
        icon: 'ant-design:file-sync-outlined',
      },
    },
    {
      path: 'templateDetail',
      name: 'TemplateDetail',
      component: () => import('/@/views/templates/TemplateDetail.vue'),
      meta: {
        title: '模板',
        icon: 'ant-design:skin-outlined',
        hideMenu: true,
      },
    },
  ],
};

export default template;
