<template>
  <div>
    <BasicTable @register="registerTable" size="small">
      <template #toolbar>
        <a-button
          preIcon="ant-design:plus-circle-outlined"
          type="primary"
          @click="openCreateTemplateModal"
        >
          新增模板组
        </a-button>
      </template>
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'name'">
          <router-link
            :to="{ name: 'TemplateDetail', query: { id: record.id } }"
            style="color: dodgerblue"
          >
            {{ record.name }}
          </router-link>
        </template>
      </template>
      <template #action="{ record }">
        <TableAction
          :actions="[
            {
              icon: 'clarity:note-edit-line',
              tooltip: '编辑模板组',
              onClick: handleEdit.bind(null, record),
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              tooltip: '删除',
              popConfirm: {
                title: '是否确认删除',
                placement: 'left',
                confirm: handleDelete.bind(null, record),
              },
            },
          ]"
        />
      </template>
    </BasicTable>

    <CreateTemplate
      @register="registerCreateTemplateModal"
      @reload="reload"
      :bodyStyle="{ 'padding-top': '0' }"
    />
    <UpdateTemplate
      @register="registerUpdateTemplateModal"
      @reload="reload"
      :bodyStyle="{ 'padding-top': '0' }"
    />
  </div>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicTable, TableAction, useTable } from '/@/components/Table';
  import {
    tableColumns,
    searchFormSchema,
    getTableListAsync,
    deleteTemplateAsync,
  } from '/@/views/templates/Template';
  import { useModal } from '/@/components/Modal';
  import CreateTemplate from './CreateTemplate.vue';
  import UpdateTemplate from './UpdateTemplate.vue';
  export default defineComponent({
    name: 'Template',
    components: {
      BasicTable,
      TableAction,
      CreateTemplate,
      UpdateTemplate,
    },
    setup() {
      // table配置
      const [registerTable, { reload }] = useTable({
        columns: tableColumns,
        formConfig: {
          labelWidth: 70,
          schemas: searchFormSchema,
        },
        api: getTableListAsync,
        showTableSetting: true,
        useSearchForm: true,
        bordered: true,
        canResize: true,
        showIndexColumn: true,
        immediate: true,
        scroll: { x: true },
        actionColumn: {
          width: 220,
          title: '操作',
          dataIndex: 'action',
          slots: { customRender: 'action' },
        },
      });
      const [registerCreateTemplateModal, { openModal: openCreateTemplateModal }] = useModal();
      const [registerUpdateTemplateModal, { openModal: openUpdateTemplateModal }] = useModal();
      // const [registerTemplateDrawer, { openDrawer: openTemplateDetailDrawer }] = useDrawer();
      function handleEdit(record: Recordable) {
        openUpdateTemplateModal(true, {
          record: record,
        });
      }
      // function handleEditDetail(record: Recordable) {
      //   openTemplateDetailDrawer(true, {
      //     record: record,
      //   });
      // }
      async function handleDelete(record: Recordable) {
        await deleteTemplateAsync({ id: record.id });
        await reload();
      }

      return {
        registerTable,
        reload,
        registerCreateTemplateModal,
        openCreateTemplateModal,
        handleEdit,
        handleDelete,
        registerUpdateTemplateModal,
        //registerTemplateDrawer,
        //handleEditDetail,
      };
    },
  });
</script>
