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
      path: 'code',
      name: 'Code',
      component: () => import('/@/views/generators/Generator.vue'),
      meta: {
        title: '自动生成',
        icon: 'ant-design:file-sync-outlined',
      },
    },
  ],
};

export default generators;
