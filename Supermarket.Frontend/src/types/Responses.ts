export interface ErrorResponse {
  response: {
    data: {
      statusCode: number;
      message: string;
    }
  }
}

export interface StringResponse {
  data: string;
}

export interface ListResponse<T> {
  data: T[];
}