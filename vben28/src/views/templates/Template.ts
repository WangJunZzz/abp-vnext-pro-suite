import { FormSchema } from "/@/components/Table";
import { BasicColumn } from "/@/components/Table";
import { formatToDateTime } from '/@/utils/dateUtil';
import { TemplatesServiceProxy,PageTemplateInput,DeleteTemplateInput } from "/@/services/ServiceProxies";

export const searchFormSchema: FormSchema[] = [
  {
    field: "filter",
    label: '关键字',
    component: "Input",
    colProps: { span: 8 }
  }
];

export const tableColumns: BasicColumn[] = [

  {
    title: "名称",
    dataIndex: "name",
  },
  {
    title: '备注',
    dataIndex: "remark"
  },
  {
    title: '创建时间',
    dataIndex: "creationTime",
    customRender: ({ text }) => {
      return formatToDateTime(text);
    }
  }
];

export const createFormSchema: FormSchema[] = [
  {
    field: "name",
    label: "名称",
    component: "Input",
    required: true,
  },
  {
    field: "remark",
    label: "备注",
    component: "InputTextArea",
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入备注',
      rows: 4,
    },
  }
];
export const editFormSchema: FormSchema[] = [
  {
    field: "id",
    label: "名称",
    component: "Input",
    required: true,
    ifShow:false
  },
  {
    field: "name",
    label: "名称",
    component: "Input",
    required: true,
  },
  {
    field: "remark",
    label: "备注",
    component: "InputTextArea",
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入备注',
      rows: 4,
    },
  }
];

export async function getTableListAsync(params: PageTemplateInput) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  return templatesServiceProxy.page(params);
}


 export async function createTemplateAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.create(params);
}

export async function deleteTemplateAsync({ id }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  const request= new DeleteTemplateInput();
  request.id=id;
  await templatesServiceProxy.delete(request);
}

export async function updateTemplateAsync({ params }) {
  const templatesServiceProxy = new TemplatesServiceProxy();
  await templatesServiceProxy.update(params);
}