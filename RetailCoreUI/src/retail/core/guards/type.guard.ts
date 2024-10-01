import { ApiResponse } from "../models/api-response.model";

// Type guard function
export function isApiResponse(error: any): error is ApiResponse<any> {
    return error && typeof error === 'object' &&
        'version' in error && typeof error.version === 'string' &&
        'statusCode' in error && typeof error.statusCode === 'number' &&
        'message' in error && typeof error.message === 'string' &&
        'result' in error &&
        'responseException' in error && typeof error.responseException === 'object';
}