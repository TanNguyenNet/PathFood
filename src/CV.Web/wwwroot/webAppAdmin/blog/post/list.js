Vue.component('paginate', VuejsPaginate);

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
            page: 1
        };
    },
    methods: {
        loadData: function (page) {
            var self = this;

            var filter = {
                page: self.page,
                pageSize: self.pSize
            };

            axios.get('/api/post/get', filter)
                .then(function (response) {
                    self.list = response.data.results;
                    self.pCount = response.data.pageCount;
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