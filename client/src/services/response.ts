export default interface Response<T> {
    data: T;
    meta: {
        count: number;
        page: number;
        pageSize: number;
        totalPages: number;
        previousPage?: number;
        nextPage?: number;
    };
}
