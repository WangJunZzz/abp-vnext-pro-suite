<template>
  <BasicModal title="复制模板组" :canFullscreen="false" @ok="submit" @register="registerModal">
    <BasicForm @register="registerTemplateForm" />
  </BasicModal>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicModal, useModalInner } from '/@/components/Modal';
  import { BasicForm, useForm } from '/@/components/Form/index';
  import { copyFormSchema, copyTemplateAsync } from '/@/views/templates/Template';

  export default defineComponent({
    name: 'CopyTemplate',
    components: {
      BasicModal,
      BasicForm,
    },
    emits: ['reload', 'register'],
    setup(_, { emit }) {
      const [registerTemplateForm, { getFieldsValue, setFieldsValue, resetFields, validate }] =
        useForm({
          labelWidth: 120,
          schemas: copyFormSchema,
          showActionButtonGroup: false,
        });
      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        setFieldsValue({
          id: data.record.id,
        });
      });

      const submit = async () => {
        try {
          await validate();
          const params = getFieldsValue();
          changeOkLoading(true);
          await copyTemplateAsync({ params });
          closeModal();
          resetFields();
          emit('reload');
        } finally {
          changeOkLoading(false);
        }
      };

      return {
        registerModal,
        registerTemplateForm,
        submit,
      };
    },
  });
</script>

<style lang="less" scoped></style>
