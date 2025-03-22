import axios from 'axios';
import type { AxiosInstance } from 'axios';

const api : AxiosInstance = axios.create({
  baseURL: import.meta.env.VITE_APP_BASE_URL, // Set base URL
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;