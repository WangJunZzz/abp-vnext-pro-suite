<template>
  <BasicModal
    title="编辑属性"
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
  import { updateEnumFormSchema, updateEnumTypeAsync } from '/@/views/entityModels/EntityModel';

  export default defineComponent({
    name: 'UpdateEnumType',
    components: {
      BasicModal,
      BasicForm,
    },
    emits: ['reload', 'register'],
    setup(_, { emit }) {
      const [registerUserForm, { getFieldsValue, setFieldsValue, validate, resetFields }] = useForm(
        {
          labelWidth: 120,
          schemas: updateEnumFormSchema,
          showActionButtonGroup: false,
        },
      );

      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        setFieldsValue({
          id: data.record.id,
          code: data.record.code,
          description: data.record.description,
        });
      });

      const submit = async () => {
        try {
          await validate();
          const params = getFieldsValue();
          changeOkLoading(true);
          await updateEnumTypeAsync({ params });
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
