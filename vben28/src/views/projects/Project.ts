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
    title: '公司名称',
    dataIndex: 'companyName',
  },
  {
    title: '项目中文名',
    dataIndex: 'name',
  },
  {
    title: '项目英文名',
    dataIndex: 'projectName',
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
    width: 200,
    customRender: ({ text }) => {
      return formatToDateTime(text);
    },
  },
];

export const createFormSchema: FormSchema[] = [
  {
    field: 'companyName',
    label: '公司名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'name',
    label: '项目中文名',
    component: 'Input',
    required: true,
  },
  {
    field: 'projectName',
    label: '项目英文名',
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
    field: 'companyName',
    label: '公司名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'name',
    label: '项目中文名',
    component: 'Input',
    required: true,
  },
  {
    field: 'projectName',
    label: '项目英文名',
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
