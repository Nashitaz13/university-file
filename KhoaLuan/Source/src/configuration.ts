import { Headers } from '@angular/http';

export class Configuration {
    // Config url of restful api
    public static readonly ApiURI = "http://192.168.137.1:52275/api/";
    //public static readonly ApiURI = "http://localhost:52275/api/";

    public static OneSignalAppId ="7095d3d7-3a10-4b6f-a35d-4c94ee5ae880";
    public static OneSignalProjectNumber = "250847158986";

    // Facebook App Id
    public static readonly FacebookAppId = 1614059478610843;
    // Headers post non auth
    public static getPostHeaderNonAuth() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return headers;
    }

}