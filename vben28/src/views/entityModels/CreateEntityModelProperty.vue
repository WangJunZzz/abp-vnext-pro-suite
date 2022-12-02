<template>
  <BasicModal
    title="新增实体属性"
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
    createEntityModelPropertyFormSchema,
    createEntityModelPropertyAsync,
  } from '/@/views/entityModels/EntityModel';

  export default defineComponent({
    name: 'CreateEntityModelProperty',
    components: {
      BasicModal,
      BasicForm,
    },
    setup(_, { emit }) {
      const [registerUserForm, { getFieldsValue, setFieldsValue, resetSchema, resetFields }] =
        useForm({
          labelWidth: 120,
          schemas: createEntityModelPropertyFormSchema,
          showActionButtonGroup: false,
        });
      let entityModelId;
      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        resetSchema(createEntityModelPropertyFormSchema);
        entityModelId = data.entityModelId;
        setFieldsValue({
          id: data.entityModelId,
        });
      });

      const submit = async () => {
        try {
          const params = getFieldsValue();
          changeOkLoading(true);
          await createEntityModelPropertyAsync({ params });
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
