import type { AppRouteModule } from '/@/router/types';
import { LAYOUT } from '/@/router/constant';

const {{ context.EntityModel.AggregateCodeCamelCase }}: AppRouteModule = {
    path: '/{{ context.EntityModel.AggregateCodeCamelCase }}',
    name: '{{ context.EntityModel.AggregateCode }}',
    component: LAYOUT,
    meta: {
        orderNo: 20,
        icon: 'ion:grid-outline',
        title: '{{ context.EntityModel.Description }}管理',
    },
    children: [
        {
            path: 'page',
            name: '{{ context.EntityModel.AggregateCode }}Page',
            component: () => import('/@/views/{{ context.EntityModel.AggregateCode }}/Index.vue'),
            meta: {
                title: '{{ context.EntityModel.Description }}列表',
                icon: 'ant-design:skin-outlined',
            },
        }
    ],
};

export default {{ context.EntityModel.AggregateCodeCamelCase }};
