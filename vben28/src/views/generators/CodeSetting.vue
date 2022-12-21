<template>
  <PageWrapper title="配置" contentBackground content="请选择项目和模板" contentClass="p-4">
    <div class="py-8 bg-white content-wrap">
      <BasicForm class="base-form" @register="register" />
      <div class="flex justify-center">
        <a-button @click="resetFields"> 重置 </a-button>
        <a-button class="!ml-4" type="primary" @click="customSubmitFunc">预览</a-button>
        <a-button class="!ml-4" type="primary" @click="customDownFunc">下载</a-button>
      </div>
    </div>
  </PageWrapper>
</template>
<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicForm, useForm } from '/@/components/Form';
  import { createFormSchema, downAsync } from './Generator';
  import { Divider } from 'ant-design-vue';
  import { PageWrapper } from '/@/components/Page';
  import { useRouter } from 'vue-router';
  export default defineComponent({
    name: 'CodeSetting',
    components: {
      BasicForm,
      [Divider.name]: Divider,
      PageWrapper,
    },
    setup() {
      const router = useRouter();
      const [register, { resetFields, validate }] = useForm({
        schemas: createFormSchema,
        showResetButton: false,
        showSubmitButton: false,
      });

      async function customSubmitFunc() {
        try {
          const values = await validate();
          const { templateId, projectId } = values;
          await router.push({
            name: 'PreViewCode',
            query: { templateId, projectId },
          });
        } catch (error) {}
      }
      async function customDownFunc() {
        try {
          const values = await validate();
          const { templateId, projectId } = values;
          await downAsync(templateId, projectId);
        } catch (error) {}
      }
      return { register, customSubmitFunc, resetFields, customDownFunc };
    },
  });
</script>
<style lang="less" scoped>
  .content-wrap {
    display: flex;
    flex-direction: column;
    align-items: center;
    .base-form {
      width: 50%;
    }
  }
</style>
