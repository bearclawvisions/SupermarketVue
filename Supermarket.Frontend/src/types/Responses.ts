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

export interface IntResponse<T> {
  data: number;
}

export interface ListResponse<T> {
  data: T[];
}