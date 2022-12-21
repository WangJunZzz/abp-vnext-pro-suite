<template>
  <BasicModal
    title="新增聚合根"
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
  import { createFormSchema, createAggregateAsync } from '/@/views/entityModels/EntityModel';

  export default defineComponent({
    name: 'CreateAggregate',
    components: {
      BasicModal,
      BasicForm,
    },
    emits: ['reload', 'register'],
    setup(_, { emit }) {
      const [registerUserForm, { getFieldsValue, setFieldsValue, resetFields, validate }] = useForm(
        {
          labelWidth: 120,
          schemas: createFormSchema,
          showActionButtonGroup: false,
        },
      );

      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        setFieldsValue({
          projectId: data.projectId,
        });
      });

      const submit = async () => {
        try {
          await validate();
          const params = getFieldsValue();
          changeOkLoading(true);
          await createAggregateAsync({ params });
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
