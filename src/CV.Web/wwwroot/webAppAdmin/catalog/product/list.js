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
            pCount: 0,
            pSize: 20,
            page: 1,
            filter: ""
        };
    },
    methods: {
        loadData: function (page) {
            var self = this;

            var filter = {
                page: self.page,
                pageSize: self.pSize,
                filter: self.filter
            };

            axios.get('/api/product/get', filter)
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
        }
    },
    created: function () {
        this.loadData(this.page);
    }
});