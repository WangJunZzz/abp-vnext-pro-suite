//import { FormSchema } from '/@/components/Table';
import { FormSchema } from '/@/components/Form';
import {
  EntityModelsServiceProxy,
  GetEntityModelTreeInput,
  DeleteAggregateInput,
  DeleteEntityModelInput,
  PageEntityModelInput,
  DataTypesServiceProxy,
  GetDataTypeInput,
  DeleteEntityModelPropertyInput,
  EnumTypesServiceProxy,
  PageEnumTypeInput,
  DeleteEnumTypeInput,
  DeleteEnumTypePropertyInput,
  PageEnumTypePropertyInput,
} from '/@/services/ServiceProxies';
import { BasicColumn } from '/@/components/Table';
export const searchFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: 'id',
    component: 'Input',
    colProps: { span: 8 },
    ifShow: false,
  },
  {
    field: 'filter',
    label: '关键字',
    component: 'Input',
    colProps: { span: 8 },
  },
];

export const tableColumns: BasicColumn[] = [
  {
    title: '编码',
    dataIndex: 'code',
    width: 180,
  },
  {
    title: '描述',
    dataIndex: 'description',
    width: 180,
  },
  {
    title: '类型',
    dataIndex: 'dataTypeDescription',
    width: 125,
  },
  {
    title: '是否必填',
    dataIndex: 'isRequired',
    width: 75,
  },
  {
    title: '最大长度',
    dataIndex: 'maxLength',
    width: 75,
  },
  {
    title: '最小长度',
    dataIndex: 'minLength',
    width: 75,
  },
  {
    title: '精度(18,6)中的18',
    dataIndex: 'decimalPrecision',
    width: 130,
  },
  {
    title: '精度(18,6)中的6',
    dataIndex: 'decimalScale',
    width: 130,
  },
];
export const tableEnumColumns: BasicColumn[] = [
  {
    title: '编码',
    dataIndex: 'code',
  },
  {
    title: '描述',
    dataIndex: 'description',
  },
];

export const tableEnumProperyColumns: BasicColumn[] = [
  {
    title: '编码',
    dataIndex: 'code',
  },

  {
    title: '值',
    dataIndex: 'value',
  },
  {
    title: '描述',
    dataIndex: 'description',
  },
];

export const createEnumFormSchema: FormSchema[] = [
  {
    field: 'entityModelId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'projectId',
    label: '项目Id',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
];

export const createEnumPropertyFormSchema: FormSchema[] = [
  {
    field: 'enumTypeId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'value',
    label: '值',
    component: 'InputNumber',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
];

export const updateEnumPropertyFormSchema: FormSchema[] = [
  {
    field: 'enumTypeId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'value',
    label: '值',
    component: 'InputNumber',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
];

export const updateEnumFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
];
export const createFormSchema: FormSchema[] = [
  {
    field: 'projectId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
];

export const createEntityModelFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
  {
    field: 'relationalType',
    component: 'Select',
    label: '关系',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      options: [
        {
          label: '一对一',
          value: '10',
          key: '10',
        },
        {
          label: '一对多',
          value: '20',
          key: '20',
        },
      ],
    },
  },
];

export const updateEntityModelFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
  {
    field: 'relationalType',
    component: 'Select',
    label: '关系',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      options: [
        {
          label: '一对一',
          value: '10',
          key: '10',
        },
        {
          label: '一对多',
          value: '20',
          key: '20',
        },
      ],
    },
  },
];

export const createEntityModelPropertyFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'enumTypeId',
    label: '枚举Id',
    component: 'Input',
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
  {
    field: 'dataTypeId',
    component: 'ApiSelect',
    label: '数据类型',

    colProps: {
      span: 16,
    },
    componentProps: ({ formModel, formActionType }) => {
      return {
        showSearch: false,
        api: getDataTypeAsync,
        getPopupContainer: () => document.body,
        labelField: 'description',
        valueField: 'id',
        immediate: true,
        params: {
          entityModelId: formModel.id,
        },
        onChange(e, option) {
          if (option.isEnum) {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
            formActionType.setFieldsValue({
              enumTypeId: e,
            });
          }

          if (option.code == 'decimal' || option.code == 'float') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: true },
              { field: 'decimalScale', ifShow: true },
            ]);
          }

          if (option.code == 'string') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: true },
              { field: 'minLength', ifShow: true },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
          }
          if (option.code == 'int' || option.code == 'long') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
          }

          if (option.code == 'bool') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
          }

          if (option.code == 'Guid') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
          }
        },
      };
    },
  },
  {
    field: 'isRequired',
    component: 'Switch',
    label: '必填',
    colProps: {
      span: 16,
    },
  },

  {
    field: 'maxLength',
    component: 'InputNumber',
    label: '最大长度',
    ifShow: false,
    componentProps: {
      max: 4096,
      min: 1,
    },
  },
  {
    field: 'minLength',
    component: 'InputNumber',
    label: '最小长度',
    ifShow: false,
    componentProps: {
      max: 4096,
      min: 1,
    },
  },
  {
    field: 'decimalPrecision',
    component: 'InputNumber',
    label: '精度(18,6)的18',
    ifShow: false,
    componentProps: {
      max: 18,
      min: 0,
    },
  },
  {
    field: 'decimalScale',
    component: 'InputNumber',
    label: '精度(18,6)的6',
    ifShow: false,
    componentProps: {
      max: 6,
      min: 0,
    },
  },
];

export const updateEntityModelPropertyFormSchema: FormSchema[] = [
  {
    field: 'id',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'propertyId',
    label: '名称',
    component: 'Input',
    required: true,
    ifShow: false,
  },
  {
    field: 'enumTypeId',
    label: '枚举Id',
    component: 'Input',
    ifShow: false,
  },
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    required: true,
  },
  {
    field: 'description',
    label: '描述',
    component: 'InputTextArea',
    required: true,
    colProps: {
      span: 16,
    },
    componentProps: {
      placeholder: '请输入描述',
      rows: 4,
    },
  },
  {
    field: 'dataTypeId',
    component: 'ApiSelect',
    label: '数据类型',

    colProps: {
      span: 16,
    },
    componentProps: ({ formModel, formActionType }) => {
      return {
        showSearch: false,
        api: getDataTypeAsync,
        getPopupContainer: () => document.body,
        labelField: 'description',
        valueField: 'id',
        immediate: true,
        params: {
          entityModelId: formModel.id,
        },
        onChange(e, option) {
          console.log(option);
          if (option.isEnum) {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
            formActionType.setFieldsValue({
              enumTypeId: e,
              maxLength: undefined,
              minLength: undefined,
              decimalPrecision: undefined,
              decimalScale: undefined,
            });
          }
          formActionType.setFieldsValue({
            enumTypeId: undefined,
          });
          if (option.code == 'decimal' || option.code == 'float') {
            formActionType.setFieldsValue({
              maxLength: undefined,
              minLength: undefined,
            });
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: true },
              { field: 'decimalScale', ifShow: true },
            ]);
          }

          if (option.code == 'string') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: true },
              { field: 'minLength', ifShow: true },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
            formActionType.setFieldsValue({
              decimalPrecision: undefined,
              decimalScale: undefined,
            });
          }
          if (option.code == 'int' || option.code == 'long') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);
            formActionType.setFieldsValue({
              maxLength: undefined,
              minLength: undefined,
              decimalPrecision: undefined,
              decimalScale: undefined,
            });
          }
          
          if (option.code == 'Guid') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);

          if (option.code == 'bool') {
            formActionType.updateSchema([
              { field: 'maxLength', ifShow: false },
              { field: 'minLength', ifShow: false },
              { field: 'decimalPrecision', ifShow: false },
              { field: 'decimalScale', ifShow: false },
            ]);

            formActionType.setFieldsValue({
              maxLength: undefined,
              minLength: undefined,
              decimalPrecision: undefined,
              decimalScale: undefined,
            });
          }
        },
      };
    },
  },
  {
    field: 'isRequired',
    component: 'Switch',
    label: '必填',
    colProps: {
      span: 16,
    },
  },

  {
    field: 'maxLength',
    component: 'InputNumber',
    label: '最大长度',
    ifShow: false,
    componentProps: {
      max: 4096,
      min: 1,
    },
  },
  {
    field: 'minLength',
    component: 'InputNumber',
    label: '最小长度',
    ifShow: false,
    componentProps: {
      max: 4096,
      min: 1,
    },
  },
  {
    field: 'decimalPrecision',
    component: 'InputNumber',
    label: '精度(18,6)的18',
    ifShow: false,
    componentProps: {
      max: 18,
      min: 0,
    },
  },
  {
    field: 'decimalScale',
    component: 'InputNumber',
    label: '精度(18,6)的6',
    ifShow: false,
    componentProps: {
      max: 6,
      min: 0,
    },
  },
];

export async function getTreeAsync({ projectId }) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  const request = new GetEntityModelTreeInput();
  request.projectId = projectId;
  return await entityModelsServiceProxy.tree(request);
}

export async function createAggregateAsync({ params }) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  await entityModelsServiceProxy.createAggregate(params);
}
export async function createEntityModelAsync({ params }) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  await entityModelsServiceProxy.createEntityModel(params);
}
export async function createEntityModelPropertyAsync({ params }) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  await entityModelsServiceProxy.createEntityModelProperty(params);
}
export async function updateEntityModelAsync({ params }) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  await entityModelsServiceProxy.updateEntityModel(params);
}

export async function updateEntityModelPropertyAsync({ params }) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  await entityModelsServiceProxy.updateEntityModelProperty(params);
}
export async function deleteAggregateAsync(id) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  const request = new DeleteAggregateInput();
  request.id = id;
  await entityModelsServiceProxy.deleteAggregate(request);
}
export async function deleteEntityModelAsync(aggregateId, id) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  const request = new DeleteEntityModelInput();
  request.aggregateId = aggregateId;
  request.id = id;
  await entityModelsServiceProxy.deleteEntityModel(request);
}

export async function deleteEntityModelPropertyAsync(id, propertyId) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  const request = new DeleteEntityModelPropertyInput();
  request.id = id;
  request.propertyId = propertyId;
  await entityModelsServiceProxy.deleteEntityModelProperty(request);
}
export async function getTableListAsync(params: PageEntityModelInput) {
  const entityModelsServiceProxy = new EntityModelsServiceProxy();
  return entityModelsServiceProxy.pageProperty(params);
}
export async function getDataTypeAsync(params: GetDataTypeInput) {
  if (params.entityModelId) {
    const dataTypesServiceProxy = new DataTypesServiceProxy();
    return dataTypesServiceProxy.list(params);
  }
}

export async function getEnumTableListAsync(params: PageEnumTypeInput) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  return enumTypesServiceProxy.page(params);
}

export async function createEnumTypeAsync({ params }) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  return enumTypesServiceProxy.createEnumType(params);
}

export async function deleteEnumTypeAsync(id) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  const request = new DeleteEnumTypeInput();
  request.id = id;

  return enumTypesServiceProxy.deleteEnumType(request);
}

export async function updateEnumTypeAsync({ params }) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  return enumTypesServiceProxy.updateEnumType(params);
}

export async function getEnumPropertyTableListAsync(params: PageEnumTypePropertyInput) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  return enumTypesServiceProxy.pageProperty(params);
}

export async function createEnumTypePropertyAsync({ params }) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  return enumTypesServiceProxy.createEnumTypeProperty(params);
}

export async function deleteEnumTypePropertyAsync(id, enumTypeId) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  const request = new DeleteEnumTypePropertyInput();
  request.id = id;
  request.enumTypeId = enumTypeId;
  return enumTypesServiceProxy.deleteEnumTypeProperty(request);
}

export async function updateEnumTypePropertyAsync({ params }) {
  const enumTypesServiceProxy = new EnumTypesServiceProxy();
  return enumTypesServiceProxy.updateEnumTypeProperty(params);
}
