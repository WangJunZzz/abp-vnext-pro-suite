<template>
  <div>
    <BasicTable @register="registerTable" size="small">
      <template #toolbar>
        <a-button
          preIcon="ant-design:plus-circle-outlined"
          type="primary"
          @click="openCreate{{ context.EntityModel.AggregateCode }}Modal"
        >
          新增{{ context.EntityModel.Description }}
        </a-button>
      </template>

      <template #action="{ record }">
        <TableAction
          :actions="[
            {
              icon: 'clarity:note-edit-line',
              label: '编辑',
              tooltip: '编辑{{ context.EntityModel.Description }}',
              onClick: handleEdit.bind(null, record),
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              label: '删除',
              tooltip: '删除{{ context.EntityModel.Description }}',
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

    <Create{{ context.EntityModel.AggregateCode }}
      @register="registerCreate{{ context.EntityModel.AggregateCode }}Modal"
      @reload="reload"
      :bodyStyle="{ 'padding-top': '0' }"
    />
    <Update{{ context.EntityModel.AggregateCode }}
      @register="registerUpdate{{ context.EntityModel.AggregateCode }}Modal"
      @reload="reload"
      :bodyStyle="{ 'padding-top': '0' }"
    />
  </div>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicTable, TableAction, useTable } from '/@/components/Table';
  import { tableColumns, searchFormSchema, pageAsync, deleteAsync } from './Index';
  import { useModal } from '/@/components/Modal';
  import Create{{ context.EntityModel.AggregateCode }} from './Create{{ context.EntityModel.AggregateCode }}.vue';
  import Update{{ context.EntityModel.AggregateCode }} from './Update{{ context.EntityModel.AggregateCode }}.vue';
  export default defineComponent({
    name: '{{ context.EntityModel.AggregateCode }}',
    components: {
      BasicTable,
      TableAction,
      Create{{ context.EntityModel.AggregateCode }},
      Update{{ context.EntityModel.AggregateCode }},
    },
    setup() {
      // table配置
      const [registerTable, { reload }] = useTable({
        columns: tableColumns,
        formConfig: {
          labelWidth: 70,
          schemas: searchFormSchema,
        },
        api: pageAsync,
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
      const [registerCreate{{ context.EntityModel.AggregateCode }}Modal, { openModal: openCreate{{ context.EntityModel.AggregateCode }}Modal }] = useModal();
      const [registerUpdate{{ context.EntityModel.AggregateCode }}Modal, { openModal: openUpdate{{ context.EntityModel.AggregateCode }}Modal }] = useModal();

      function handleEdit(record: Recordable) {
        openUpdate{{ context.EntityModel.AggregateCode }}Modal(true, {
          record: record,
        });
      }
    
      async function handleDelete(record: Recordable) {
        await deleteAsync({ id: record.id });
        await reload();
      }

      return {
        registerTable,
        reload,
        handleEdit,
        handleDelete,
        registerCreate{{ context.EntityModel.AggregateCode }}Modal,
        registerUpdate{{ context.EntityModel.AggregateCode }}Modal,
        openCreate{{ context.EntityModel.AggregateCode }}Modal
      };
    },
  });
</script>
