import { FormSchema } from '/@/components/Table';
import { BasicColumn } from '/@/components/Table';
import { formatToDateTime } from '/@/utils/dateUtil';
import {
  ProjectsServiceProxy,
  PageProjectInput,
  DeleteProjectInput,
} from '/@/services/ServiceProxies';

export const searchFormSchema: FormSchema[] = [
  {
    field: 'filter',
    label: '关键字',
    component: 'Input',
    colProps: { span: 8 },
  },
];

export const tableColumns: BasicColumn[] = [
  {
    title: '名称',
    dataIndex: 'name',
  },
  {
    title: '名称空间',
    dataIndex: 'nameSpace',
  },
  {
    title: '拥有者',
    dataIndex: 'owner',
  },
  {
    title: '备注',
    dataIndex: 'remark',
  },
  {
    title: '创建时间',
    dataIndex: 'creationTime',
    customRender: ({ text }) => {
      return formatToDateTime(text);
    },
  },
];

export const createFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'nameSpace',
    label: '名称空间',
    component: 'Input',
    required: true,
  },
  {
    field: 'owner',
    label: '拥有者',
    component: 'Input',
  },
  {
    field: 'remark',
    label: '备注',
    component: 'InputTextArea',
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入备注',
      rows: 4,
    },
  },
];
export const editFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'name',
    label: '名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'nameSpace',
    label: '名称空间',
    component: 'Input',
    required: true,
  },
  {
    field: 'owner',
    label: '拥有者',
    component: 'Input',
    required: true,
  },
  {
    field: 'remark',
    label: '备注',
    component: 'InputTextArea',
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入备注',
      rows: 4,
    },
  },
];

export async function getTableListAsync(params: PageProjectInput) {
  const projectsServiceProxy = new ProjectsServiceProxy();
  return projectsServiceProxy.page(params);
}

export async function createProjectAsync({ params }) {
  const projectsServiceProxy = new ProjectsServiceProxy();
  await projectsServiceProxy.create(params);
}

export async function deleteProjectAsync({ id }) {
  const projectsServiceProxy = new ProjectsServiceProxy();
  const request = new DeleteProjectInput();
  request.id = id;
  await projectsServiceProxy.delete(request);
}

export async function updateProjectAsync({ params }) {
  const projectsServiceProxy = new ProjectsServiceProxy();
  await projectsServiceProxy.update(params);
}
