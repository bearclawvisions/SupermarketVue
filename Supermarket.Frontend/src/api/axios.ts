import axios from 'axios';
import type { AxiosInstance } from 'axios';


const api : AxiosInstance = axios.create({
  baseURL: import.meta.env.VITE_APP_BASE_URL, // Set base URL
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.request.use(
  (config) => {
    const csrfToken = getCookie("X-XSRF-TOKEN");
    if (csrfToken) {
      config.headers['X-XSRF-TOKEN'] = csrfToken;
    }

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

function getCookie(name: string): string | undefined {
  const match = document.cookie.match(new RegExp('(^| )' + name + '=([^;]+)'));
  if (match) {
    return match[2]; // Return the value of the cookie
  }
  return undefined;
}

export default api;