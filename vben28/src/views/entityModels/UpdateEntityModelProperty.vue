<template>
  <BasicModal
    title="编辑实体属性"
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
    updateEntityModelPropertyFormSchema,
    updateEntityModelPropertyAsync,
  } from '/@/views/entityModels/EntityModel';

  export default defineComponent({
    name: 'UpdateEntityModelProperty',
    components: {
      BasicModal,
      BasicForm,
    },
    setup(_, { emit }) {
      const [
        registerUserForm,
        { getFieldsValue, setFieldsValue, resetSchema, updateSchema, resetFields },
      ] = useForm({
        labelWidth: 120,
        schemas: updateEntityModelPropertyFormSchema,
        showActionButtonGroup: false,
      });

      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        resetSchema(updateEntityModelPropertyFormSchema);

        setFieldsValue({
          propertyId: data.record.id,
          id: data.record.entityModelId,
          code: data.record.code,
          description: data.record.description,
          dataTypeId: data.record.dataTypeId,
          enumTypeId: data.record.enumTypeId,
          isRequired: data.record.isRequired,
          maxLength: data.record.maxLength,
          minLength: data.record.minLength,
          decimalPrecision: data.record.decimalPrecision,
          decimalScale: data.record.decimalScale,
        });
        if (data.record.isEnum) {
          updateSchema([
            { field: 'maxLength', ifShow: false },
            { field: 'minLength', ifShow: false },
            { field: 'decimalPrecision', ifShow: false },
            { field: 'decimalScale', ifShow: false },
          ]);
        }

        if (data.record.dataTypeCode == 'decimal' || data.record.dataTypeCode == 'float') {
          updateSchema([
            { field: 'maxLength', ifShow: false },
            { field: 'minLength', ifShow: false },
            { field: 'decimalPrecision', ifShow: true },
            { field: 'decimalScale', ifShow: true },
          ]);
        }

        if (data.record.dataTypeCode == 'string') {
          updateSchema([
            { field: 'maxLength', ifShow: true },
            { field: 'minLength', ifShow: true },
            { field: 'decimalPrecision', ifShow: false },
            { field: 'decimalScale', ifShow: false },
          ]);
          setFieldsValue({
            maxLength: data.record.maxLength,
            minLength: data.record.maxLength,
          });
        }
        if (data.record.dataTypeCode == 'int' || data.record.dataTypeCode == 'long') {
          updateSchema([
            { field: 'maxLength', ifShow: false },
            { field: 'minLength', ifShow: false },
            { field: 'decimalPrecision', ifShow: false },
            { field: 'decimalScale', ifShow: false },
          ]);
        }

        if (data.record.dataTypeCode == 'bool') {
          updateSchema([
            { field: 'maxLength', ifShow: false },
            { field: 'minLength', ifShow: false },
            { field: 'decimalPrecision', ifShow: false },
            { field: 'decimalScale', ifShow: false },
          ]);
        }
      });

      const submit = async () => {
        try {
          const params = getFieldsValue();
          changeOkLoading(true);
          await updateEntityModelPropertyAsync({ params });
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
