export interface Pagination {
    curentPage: number;
    itemPerPage: number;
    totalItems: number;
    totalPages: number;
}

export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}


