import { FormSchema } from '/@/components/Table';
import { BasicColumn } from '/@/components/Table';
import { formatToDateTime } from '/@/utils/dateUtil';
import {
  TemplatesServiceProxy,
  PageTemplateInput,
  DeleteTemplateInput,
  GetTemplteTreeInput,
  GetTemplateTreeOutput,
  DeleteTemplateDetailInput,
  UpdateTemplateDetailContentInput,
} from '/@/services/ServiceProxies';
import { message } from 'ant-design-vue';
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

export const createTemplateDetailSchema: FormSchema[] = [
  {
    field: 'templateId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'parentId',
    label: 'parentId',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'templateType',
    component: 'ApiSelect',
    label: '类型',
    colProps: {
      span: 16,
    },
    ifShow: true,
    componentProps: ({ formModel, formActionType }) => {
      return {
        showSearch: false,
        api: getTemplateTypeAsync,
        getPopupContainer: () => document.body,
        labelField: 'key',
        valueField: 'value',
        immediate: true,
        onChange(e, option) {
          if (e == 20) {
            formActionType.updateSchema([{ field: 'controlType', ifShow: true }]);
          } else {
            formActionType.updateSchema([{ field: 'controlType', ifShow: false }]);
          }
        },
      };
    },
  },

  {
    field: 'controlType',
    component: 'ApiSelect',
    label: '模板策略',
    colProps: {
      span: 16,
    },
    ifShow: false,
    componentProps: ({ formModel, formActionType }) => {
      return {
        showSearch: false,
        api: getControlTypeAsync,
        getPopupContainer: () => document.body,
        labelField: 'key',
        valueField: 'value',
        immediate: true,
      };
    },
  },
  {
    field: 'name',
    label: '名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    required: true,
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

export const updateTemplateDetailSchema: FormSchema[] = [
  {
    field: 'templateId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'templateDetailId',
    label: 'templateDetailId',
    component: 'Input',
    required: true,
    ifShow: false,
  },

  {
    field: 'controlType',
    component: 'ApiSelect',
    label: '模板策略',
    colProps: {
      span: 16,
    },
    ifShow: false,
    componentProps: ({ formModel, formActionType }) => {
      return {
        showSearch: false,
        api: getControlTypeAsync,
        getPopupContainer: () => document.body,
        labelField: 'key',
        valueField: 'value',
        immediate: true,
      };
    },
  },
  {
    field: 'name',
    label: '名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    required: true,
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
export const copyFormSchema: FormSchema[] = [
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
export async function getTableListAsync(params: PageTemplateInput) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  return templatesServiceProxy.page(params);
}

export async function createTemplateAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.create(params);
}
export async function createTemplateDetailNoContentAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.createDetail(params);
}
export async function updateTemplateDetailNoContentAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.updateDetail(params);
}
export async function createTemplateDetailAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.createDetail(params);
}
export async function deleteTemplateAsync({ id }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  const request = new DeleteTemplateInput();
  request.id = id;
  await templatesServiceProxy.delete(request);
}
export async function deleteTemplateDetailAsync({ templateId, templateDetailId }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  const request = new DeleteTemplateDetailInput();
  request.templateId = templateId;
  request.templateDetailId = templateDetailId;
  await templatesServiceProxy.deleteDetail(request);
}
export async function updateTemplateAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.update(params);
}

export async function getTemplateTreeAsync({ templateId }): Promise<GetTemplateTreeOutput[]> {
  const templatesServiceProxy = new TemplatesServiceProxy();
  const request = new GetTemplteTreeInput();
  request.templateId = templateId;
  return await templatesServiceProxy.tree(request);
}
export async function saveTemplateDetailAsync(templateId, templateDetailId, content) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  const request = new UpdateTemplateDetailContentInput();
  request.templateId = templateId;
  request.templateDetailId = templateDetailId;
  request.content = content;
  await templatesServiceProxy.updateDetailContent(request);
  message.success('更新模板成功');
}
export async function getControlTypeAsync() {
  const templatesServiceProxy = new TemplatesServiceProxy();
  return templatesServiceProxy.controlType();
}
export async function getTemplateTypeAsync() {
  const templatesServiceProxy = new TemplatesServiceProxy();
  return templatesServiceProxy.templateType();
}

export async function copyTemplateAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  return templatesServiceProxy.copy(params);
}
