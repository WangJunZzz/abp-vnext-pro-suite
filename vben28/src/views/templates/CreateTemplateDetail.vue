<template>
  <BasicModal
    title="新增模板"
    :canFullscreen="false"
    @ok="submit"
    @cancel="cancel"
    @register="registerModal"
  >
    <BasicForm @register="registerUserForm" />
  </BasicModal>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicModal, useModalInner } from '/@/components/Modal';
  import { BasicForm, useForm } from '/@/components/Form/index';
  import {
    createTemplateDetailSchema,
    createTemplateDetailNoContentAsync,
  } from '/@/views/templates/Template';

  export default defineComponent({
    name: 'CreateTemplateDetail',
    components: {
      BasicModal,
      BasicForm,
    },
    emits: ['reload', 'register'],
    setup(_, { emit }) {
      const [
        registerUserForm,
        { getFieldsValue, setFieldsValue, validate, resetFields, updateSchema, resetSchema },
      ] = useForm({
        labelWidth: 120,
        schemas: createTemplateDetailSchema,
        showActionButtonGroup: false,
      });

      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        resetSchema(createTemplateDetailSchema);
        setFieldsValue({
          templateId: data.templateId,
          parentId: data.parentId,
        });
        if (data.templateType) {
          setFieldsValue({
            templateType: data.templateType,
          });
          updateSchema({
            field: 'templateType',
            ifShow: false,
          });
        }

        if (data.templateType == 20) {
          updateSchema({
            field: 'controlType',
            ifShow: true,
          });
        }
      });

      const submit = async () => {
        try {
          await validate();
          const params = getFieldsValue();
          changeOkLoading(true);
          await createTemplateDetailNoContentAsync({ params });
          await resetFields();
          closeModal();
          emit('reload');
        } finally {
          changeOkLoading(false);
        }
      };

      const cancel = () => {
        resetFields();
        closeModal();
      };
      return {
        registerModal,
        registerUserForm,
        submit,
        cancel,
      };
    },
  });
</script>

<style lang="less" scoped></style>
