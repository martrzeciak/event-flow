import { map } from "rxjs";
import { PaginatedResult } from "../models/pagination";
import { HttpClient, HttpParams } from "@angular/common/http";

export function getPaginatedResult<T>(url: string, params: HttpParams, http: HttpClient) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return http.get<T>(url, { observe: 'response', params }).pipe(
        map(respone => {
            if (respone.body) {
                paginatedResult.result = respone.body;
            }
            const pagination = respone.headers.get('Pagination');
            if (pagination) {
                paginatedResult.pagination = JSON.parse(pagination);
            }
            return paginatedResult;
        })
    );
}