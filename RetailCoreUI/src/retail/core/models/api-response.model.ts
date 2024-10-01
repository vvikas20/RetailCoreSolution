export interface ApiResponse<T> {
    version: string,
    statusCode: number;
    message: string;
    result: T;
    responseException: ApiError;
}

export interface ApiError {
    isError: boolean;
    exceptionMessage: string;
    details: string;
    referenceErrorCode: string;
    referenceDocumentLink: string;
    validationErrors: any;
}