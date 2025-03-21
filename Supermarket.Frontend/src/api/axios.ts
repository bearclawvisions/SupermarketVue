import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_APP_BASE_URL, // Set base URL
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;