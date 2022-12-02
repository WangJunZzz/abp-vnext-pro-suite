<template>
    <BasicModal
      title="新增枚举属性"
      :canFullscreen="false"
      @ok="submit"
      @cancel="cancel"
      @register="registerModal"
    >
      <BasicForm @register="registerUserForm" />
    </BasicModal>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  import { BasicModal, useModalInner } from "/@/components/Modal";
  import { BasicForm, useForm } from "/@/components/Form/index";
  import { createEnumPropertyFormSchema, createEnumTypePropertyAsync } from "/@/views/entityModels/EntityModel";
  
  export default defineComponent({
    name: "CreateEnumTypeProperty",
    components: {
      BasicModal,
      BasicForm
    },
    setup(_, { emit }) {
  
      const [registerUserForm, { getFieldsValue,setFieldsValue,  resetFields }] = useForm({
        labelWidth: 120,
        schemas: createEnumPropertyFormSchema,
        showActionButtonGroup: false
      });
  
      const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data)=>{
        setFieldsValue({
            enumTypeId: data.enumTypeId,
        });
      });
  
      const submit = async () => {
        try {
          const params = getFieldsValue();
          changeOkLoading(true);;
          await createEnumTypePropertyAsync({params});
          await resetFields();
          closeModal();
          emit("reload");
        } finally{
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
        cancel
      };
    }
  });
  </script>
  
  <style lang="less" scoped></style>
  