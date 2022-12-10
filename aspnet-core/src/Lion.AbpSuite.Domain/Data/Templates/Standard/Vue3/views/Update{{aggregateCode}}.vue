<template>
  <BasicModal title="编辑{{ context.EntityModel.Description }}" :canFullscreen="false" @ok="submit" @register="register{{ context.EntityModel.AggregateCode }}Modal">
    <BasicForm @register="register{{ context.EntityModel.AggregateCode }}Form" />
  </BasicModal>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicModal, useModalInner } from '/@/components/Modal';
  import { BasicForm, useForm } from '/@/components/Form/index';
  import { updateFormSchema, updateAsync } from './Index';

  export default defineComponent({
    name: 'Update{{ context.EntityModel.AggregateCode }}',
    components: {
      BasicModal,
      BasicForm,
    },
    emits: ['reload', 'register'],
    setup(_, { emit }) {
      const [register{{ context.EntityModel.AggregateCode }}Form, { getFieldsValue, setFieldsValue }] = useForm({
        labelWidth: 120,
        schemas: updateFormSchema,
        showActionButtonGroup: false,
      });
      const [register{{ context.EntityModel.AggregateCode }}Modal, { changeOkLoading, closeModal }] = useModalInner((data) => {
        setFieldsValue({
          id: data.record.id,
    {{~ for prop in context.EntityModel.Properties ~}}
          {{prop.CodeCamelCase}}: data.record.{{prop.CodeCamelCase}},
    {{~ end ~}} 
        });
      });

      const submit = async () => {
        try {
          const params = getFieldsValue();
          changeOkLoading(true);
          await updateAsync({ params });
          closeModal();
          emit('reload');
        } finally {
          changeOkLoading(false);
        }
      };

      return {
        register{{ context.EntityModel.AggregateCode }}Modal,
        register{{ context.EntityModel.AggregateCode }}Form,
        submit,
      };
    },
  });
</script>

<style lang="less" scoped></style>
