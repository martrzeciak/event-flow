export class EventParams {
    pageNumber = 1;
    pageSize = 8;
    orderBy = "date";
    search = '';
    categories: string[] = [];
    dateFrom?: Date;
    dateTo?: Date;  
}