<template>
  <BasicModal
    title="新增{{ context.EntityModel.Description }}"
    :canFullscreen="false"
    @ok="submit"
    @cancel="cancel"
    @register="register{{ context.EntityModel.AggregateCode }}Modal"
  >
    <BasicForm @register="register{{ context.EntityModel.AggregateCode }}Form" />
  </BasicModal>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicModal, useModalInner } from '/@/components/Modal';
  import { BasicForm, useForm } from '/@/components/Form/index';
  import { createFormSchema, createAsync } from './Index';

  export default defineComponent({
    name: 'Create{{ context.EntityModel.AggregateCode }}',
    components: {
      BasicModal,
      BasicForm,
    },
    emits: ['reload', 'register'],
    setup(_, { emit }) {
      const [register{{ context.EntityModel.AggregateCode }}Form, { getFieldsValue, resetFields, validate }] = useForm({
        labelWidth: 120,
        schemas: createFormSchema,
        showActionButtonGroup: false,
      });

      const [register{{ context.EntityModel.AggregateCode }}Modal, { changeOkLoading, closeModal }] = useModalInner();

      const submit = async () => {
        try {
          const params = getFieldsValue();
          changeOkLoading(true);
          await validate();
          await createAsync({ params });
          await resetFields();
          emit('reload');
          closeModal();
        } finally {
          changeOkLoading(false);
        }
      };

      const cancel = () => {
        resetFields();
        closeModal();
      };
      return {
        register{{ context.EntityModel.AggregateCode }}Modal,
        register{{ context.EntityModel.AggregateCode }}Form,
        submit,
        cancel,
      };
    },
  });
</script>

<style lang="less" scoped></style>
