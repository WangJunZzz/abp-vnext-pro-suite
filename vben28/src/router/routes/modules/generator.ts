import type { AppRouteModule } from '/@/router/types';
import { LAYOUT } from '/@/router/constant';
const generators: AppRouteModule = {
  path: '/generators',
  name: 'Generators',
  component: LAYOUT,
  meta: {
    orderNo: 60,
    icon: 'ant-design:send-outlined',
    title: '代码管理',
  },
  children: [
    {
      path: 'setting',
      name: 'Setting',
      component: () => import('/@/views/generators/CodeSetting.vue'),
      meta: {
        title: '预览',
        icon: 'ant-design:file-sync-outlined',
      },
    },
    {
      path: 'preViewCode',
      name: 'PreViewCode',
      component: () => import('/@/views/generators/PreViewCode.vue'),
      meta: {
        title: '预览',
        icon: 'ant-design:file-sync-outlined',
        hideMenu: true,
      },
    },
  ],
};

export default generators;
