Vue.component('paginate', VuejsPaginate);
window.Vue.use(VuejsDialog.main.default);

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            list: [],
            pCount: 0,
            pSize: 20,
            page: 1
        };
    },
    methods: {
        loadData: function (page) {
            var self = this;

            var params = {
                page: self.page,
                pageSize: self.pSize
            };

            axios.get('/api/question/get', { params })
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
                    axios.delete('/api/question/delete/' + id, null)
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
        }
    },
    created: function () {
        this.loadData(this.page);
    }
});