const sfcLoader = window['vue3-sfc-loader'] || window['vue3SfcLoader'];

const options = {
    moduleCache: { vue: Vue },
    async getFile(url) {
        const res = await fetch(url);
        if (!res.ok) throw Object.assign(new Error(res.statusText + ' ' + url), { res });
        return {
            getContentData: (asBinary) => asBinary ? res.arrayBuffer() : res.text(),
        }
    },
    addStyle(textContent) {
        const style = Object.assign(document.createElement('style'), { textContent });
        document.head.appendChild(style);
    },
};

window.initVuePage = function (componentName, initialProps = {}, selector = '#vueApp') {
    const { loadModule } = sfcLoader;

    const app = Vue.createApp({
        components: {
            'v-main-page': Vue.defineAsyncComponent(() => loadModule('/vue/pages/' + componentName, options))
        },
        template: `<v-main-page v-bind="pageProps"></v-main-page>`,
        setup() {
            return { pageProps: initialProps };
        }
    });

    app.mount(selector);
    return app;
};