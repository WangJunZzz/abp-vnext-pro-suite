<template>
    <BasicModal
      title="编辑枚举属性"
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
        updateEnumPropertyFormSchema,
        updateEnumTypePropertyAsync,
    } from '/@/views/entityModels/EntityModel';
  
    export default defineComponent({
      name: 'UpdateEnumTypeProperty',
      components: {
        BasicModal,
        BasicForm,
      },
      setup(_, { emit }) {
        const [
          registerUserForm,
          { getFieldsValue, setFieldsValue, validate, resetFields },
        ] = useForm({
          labelWidth: 120,
          schemas: updateEnumPropertyFormSchema,
          showActionButtonGroup: false,
        });
  
        const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
          console.log(data)
          setFieldsValue({
            enumTypeId:data.enumTypeId,
            id: data.id,
            code: data.code,
            value:data.value,
            description: data.description
          });
        });
  
        const submit = async () => {
          try {
            await validate();
            const params = getFieldsValue();
            changeOkLoading(true);
            await updateEnumTypePropertyAsync({ params });
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
  