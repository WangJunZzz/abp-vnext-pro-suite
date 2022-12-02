import { FormSchema } from '/@/components/Table';

export const step1Schemas: FormSchema[] = [
  {
    field: 'account',
    component: 'Select',
    label: '付款账户',
    required: true,
    defaultValue: '1',
    componentProps: {
      options: [
        {
          label: 'anncwb@126.com',
          value: '1',
        },
      ],
    },
    colProps: {
      span: 24,
    },
  },
  {
    field: 'fac',
    component: 'InputGroup',
    label: '收款账户',
    required: true,
    defaultValue: 'test@example.com',
    slot: 'fac',
    colProps: {
      span: 24,
    },
  },
  {
    field: 'pay',
    component: 'Input',
    label: '',
    defaultValue: 'zfb',
    show: false,
  },
  {
    field: 'payeeName',
    component: 'Input',
    label: '收款人姓名',
    defaultValue: 'Vben',
    required: true,
    colProps: {
      span: 24,
    },
  },
  {
    field: 'money',
    component: 'Input',
    label: '转账金额',
    defaultValue: '500',
    required: true,
    renderComponentContent: () => {
      return {
        prefix: () => '￥',
      };
    },
    colProps: {
      span: 24,
    },
  },
];

export const step2Schemas: FormSchema[] = [
  {
    field: 'pwd',
    component: 'InputPassword',
    label: '支付密码',
    required: true,
    defaultValue: '123456',
    colProps: {
      span: 24,
    },
  },
];

export const growCardList: GrowCardItem[] = [
  {
    title: '访问数',
    icon: 'visit-count|svg',
    value: 2000,
    total: 120000,
    color: 'green',
    action: '月',
  },
  {
    title: '成交额',
    icon: 'total-sales|svg',
    value: 20000,
    total: 500000,
    color: 'blue',
    action: '月',
  },
  {
    title: '下载数',
    icon: 'download-count|svg',
    value: 8000,
    total: 120000,
    color: 'orange',
    action: '周',
  },
  {
    title: '成交数',
    icon: 'transaction|svg',
    value: 5000,
    total: 50000,
    color: 'purple',
    action: '年',
  },
];
