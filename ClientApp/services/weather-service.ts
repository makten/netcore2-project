// import axios from 'axios';

// class Weather {

//     async conditions(city) {
//         const query = `select item.condition from weather.forecast where woeid in (select woeid from geo.places(1) where text='${city}') and u='c'`;

//         const response = await this.performQuery(query);

//         return response.data.query.results.channel.item.condition;
//     }

//     async performQuery(query) {
//         const endpoint = `https://query.yahooapis.com/v1/public/yql?q=${query}&format=json`;
//         // https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22nome%2C%20ak%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys

//         return await axios.get(endpoint);
//     }
// }

// export default new Weather();
