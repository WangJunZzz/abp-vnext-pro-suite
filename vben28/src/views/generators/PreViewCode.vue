<template>
  <PageWrapper dense contentFullHeight contentClass="flex">
    <div class="bg-white m-4 mr-0 w-1/4 xl:w-1/5 overflow-hidden">
      <BasicTree toolbar search showIcon :treeData="treeData" @select="handleSelect" />
    </div>
    <div class="bg-white m-4 p-4 mr-0 w-3/4 xl:w-4/5">
      <CodeEditor v-model:value="content" />
    </div>
    <Loading :loading="loading" :absolute="absolute" :tip="tip" />
  </PageWrapper>
</template>
<script lang="ts">
  import { defineComponent, ref, onActivated, reactive, toRefs } from 'vue';
  import { useRoute } from 'vue-router';
  import { PageWrapper } from '/@/components/Page';
  import { TemplateTreeDto } from '/@/services/ServiceProxies';
  import { BasicTree } from '/@/components/Tree';
  import { CodeEditor } from '/@/components/CodeEditor';
  import { preViewCodeAsync } from './Generator';
  import { Loading } from '/@/components/Loading';
  export default defineComponent({
    name: 'PreViewCode',
    components: {
      PageWrapper,
      BasicTree,
      CodeEditor,
      Loading,
    },
    setup() {
      const compState = reactive({
        absolute: false,
        loading: false,
        tip: '正在努力生成代码...',
      });
      const treeData = ref<TemplateTreeDto[]>([]);
      const showLine = ref<boolean>(true);
      const showIcon = ref<boolean>(true);
      const content = ref<string>('');
      const modeValue = ref('application/json');
      const route = useRoute();
      onActivated(async () => {
        if (route.query?.templateId && route.query?.projectId) {
          compState.loading = true;
          await loadTree();
          compState.loading = false;
        } else {
        }
      });
      async function loadTree() {
        treeData.value = await preViewCodeAsync({
          templateId: route.query?.templateId,
          projectId: route.query?.projectId,
        });
      }
      function handleSelect(selectedKeys, e: { selected: boolean; selectedNodes; node; event }) {
        content.value = '';
        if (e.node.templateType != 10) {
          content.value = e.node.content;
        } else {
        }
      }
      return {
        treeData,
        modeValue,
        showLine,
        showIcon,
        handleSelect,
        content,
        loadTree,
        ...toRefs(compState),
      };
    },
  });
</script>
