<template>
    <BasicModal title="编辑项目" :canFullscreen="false" @ok="submit" @register="registerModal">
      <BasicForm @register="registerProjectForm" />
    </BasicModal>
  </template>
  
  <script lang="ts">
    import { defineComponent } from 'vue';
    import { BasicModal, useModalInner } from '/@/components/Modal';
    import { BasicForm, useForm } from '/@/components/Form/index';
    import { editFormSchema, updateProjectAsync }  from '/@/views/projects/Project1';
  
    export default defineComponent({
      name: 'UpdateProject',
      components: {
        BasicModal,
        BasicForm,
      },
      emits: ['reload', 'register'],
      setup(_, { emit }) {
        const [registerProjectForm, { getFieldsValue, setFieldsValue }] = useForm({
          labelWidth: 120,
          schemas: editFormSchema,
          showActionButtonGroup: false,
        });
        const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {
          setFieldsValue({
            id: data.record.id,
            name: data.record.name,
            nameSpace: data.record.nameSpace,
            owner: data.record.owner,
            remark: data.record.remark,
          });
        });
  
        const submit = async () => {
          try {
            const params = getFieldsValue();
            changeOkLoading(true);
            await updateProjectAsync({ params });
            closeModal();
            emit('reload');
          } finally {
            changeOkLoading(false);
          }
        };
  
        return {
          registerModal,
          registerProjectForm,
          submit,
        };
      },
    });
  </script>
  
  <style lang="less" scoped></style>
  