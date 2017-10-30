import axios from 'axios';
var xhrRequest = axios.create({
    baseURL: 'http://hranalyticswebapi.azurewebsites.net',
    method: 'post'
});

export default xhrRequest;
// axios.defaults.baseURL = 'https://api.example.com';
// axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
// axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';