import axios from 'axios';
import toast from 'react-hot-toast';

const api = axios.create({
	baseURL: 'http://localhost:5010/api',
});

api.interceptors.response.use(
	(response) => response,
	(error) => {
		const message =
			error.response?.data?.detail || 'An unexpected error occurred';

		if (message.includes('|')) {
			message.split('|').forEach((msg) => toast.error(msg.trim()));
		} else {
			toast.error(message);
		}
		return Promise.reject(error);
	},
);

export default api;
