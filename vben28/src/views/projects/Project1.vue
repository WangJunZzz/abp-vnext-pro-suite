<template>
  <div>
    <BasicTable @register="registerTable" size="small">
      <template #toolbar>
        <a-button
          preIcon="ant-design:plus-circle-outlined"
          type="primary"
          @click="openCreateProjectModal"
        >
          新增项目
        </a-button>
      </template>
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'name'">
          <router-link
            :to="{ name: 'EntityModel', query: { id: record.id } }"
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
              tooltip: '编辑项目',
              onClick: handleEdit.bind(null, record),
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              tooltip: '删除项目',
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

    <CreateProject
      @register="registerCreateProjectModal"
      @reload="reload"
      :bodyStyle="{ 'padding-top': '0' }"
    />
    <UpdateProject
      @register="registerUpdateProjectModal"
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
    deleteProjectAsync,
  } from '/@/views/projects/Project1';
  import { useModal } from '/@/components/Modal';
  import CreateProject from './CreateProject.vue';
  import UpdateProject from './UpdateProject.vue';
  export default defineComponent({
    name: 'Project',
    components: {
      BasicTable,
      TableAction,
      CreateProject,
      UpdateProject,
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
      const [registerCreateProjectModal, { openModal: openCreateProjectModal }] = useModal();
      const [registerUpdateProjectModal, { openModal: openUpdateProjectModal }] = useModal();

      function handleEdit(record: Recordable) {
        openUpdateProjectModal(true, {
          record: record,
        });
      }

      async function handleDelete(record: Recordable) {
        await deleteProjectAsync({ id: record.id });
        await reload();
      }

      return {
        registerTable,
        reload,
        registerCreateProjectModal,
        openCreateProjectModal,
        handleEdit,
        handleDelete,
        registerUpdateProjectModal,
      };
    },
  });
</script>
