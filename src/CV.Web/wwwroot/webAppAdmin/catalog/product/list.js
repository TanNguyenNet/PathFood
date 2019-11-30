Vue.component('paginate', VuejsPaginate);
window.Vue.use(VuejsDialog.main.default);

Vue.filter('formatDate', function (value) {
    return moment(value).format('DD/MM/YYYY hh:mm');
});

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            list: [],
            langs: [],
            pCount: 0,
            pSize: 20,
            page: 1,
            filter: "",
            lang: null
        };
    },
    methods: {
        loadData: function (page) {
            var self = this;

            var params = {
                page: self.page,
                pageSize: self.pSize,
                filter: self.filter,
                lang: self.lang
            };

            axios.get('/api/product/get', {
                params
            })
                .then(function (response) {
                    self.list = response.data.results;
                    self.pCount = response.data.pageCount;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        deleteItem: function (id) {
            var self = this;

            self.$dialog
                .confirm('Bạn muốn xóa')
                .then(function (dialog) {
                    axios.delete('/api/product/delete/' + id, null)
                        .then(function (response) {
                            self.loadData(self.page);
                        })
                        .catch(function (error) {
                            alert("ERROR: " + (error.message | error));
                        });
                })
                .catch(function () {
                    console.log('Error');
                });
        },
        loadLang: function () {
            var self = this;
            axios.get('/api/setting/GetLanguages/', null)
                .then(function (response) {
                    self.langs = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadData(this.page);
    }
});