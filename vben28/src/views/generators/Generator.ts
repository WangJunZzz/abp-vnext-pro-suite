import {
  ProjectsServiceProxy,
  TemplatesServiceProxy,
  GeneratorServiceProxy,
  PreViewCodeInput,
} from '/@/services/ServiceProxies';
import { FormSchema } from '/@/components/Form';
export const createFormSchema: FormSchema[] = [
  {
    field: 'projectId',
    label: '项目',
    labelWidth: 100,
    component: 'ApiSelect',
    required: true,
    colProps: {
      span: 24,
    },
    componentProps: () => {
      return {
        showSearch: false,
        api: getProjectListAsync,
        getPopupContainer: () => document.body,
        labelField: 'name',
        valueField: 'id',
      };
    },
  },
  {
    field: 'templateId',
    label: '模板组',
    labelWidth: 100,
    required: true,
    component: 'ApiSelect',
    colProps: {
      span: 24,
    },
    componentProps: () => {
      return {
        showSearch: false,
        api: getTemplateListAsync,
        getPopupContainer: () => document.body,
        labelField: 'name',
        valueField: 'id',
      };
    },
  },
];
export async function getProjectListAsync() {
  const projectsServiceProxy = new ProjectsServiceProxy();
  return projectsServiceProxy.all();
}
export async function getTemplateListAsync() {
  const templatesServiceProxy = new TemplatesServiceProxy();
  return templatesServiceProxy.all();
}
export async function preViewCodeAsync({ templateId, projectId }) {
  const generatorServiceProxy = new GeneratorServiceProxy();
  const request = new PreViewCodeInput();
  request.templateId = templateId;
  request.projectId = projectId;
  return generatorServiceProxy.preViewCode(request);
}
