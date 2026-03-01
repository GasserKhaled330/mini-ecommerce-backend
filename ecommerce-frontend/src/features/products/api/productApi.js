import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import toast from 'react-hot-toast';
import api from '../../../api/axios';

export const useProducts = (page = 1, size = 10) => {
	return useQuery({
		queryKey: ['products', page, size],
		queryFn: async () => {
			const { data } = await api.get(
				`/products?pageNumber=${page}&pageSize=${size}`,
			);
			return data;
		},
	});
};

export const useCreateProduct = () => {
	const queryClient = useQueryClient();
	return useMutation({
		mutationFn: (newProduct) => api.post('/products', newProduct),
		onSuccess: async () => {
			await queryClient.invalidateQueries({ queryKey: ['products'] });
			toast.success('Product created successfully!');
		},
	});
};

export const useUpdateProduct = () => {
	const queryClient = useQueryClient();
	return useMutation({
		mutationFn: ({ id, data }) => api.put(`/products/${id}`, data),
		onSuccess: async () => {
			await queryClient.invalidateQueries({ queryKey: ['products'] });
			toast.success('Product updated successfully!');
		},
	});
};

export const useDeleteProduct = () => {
	const queryClient = useQueryClient();
	return useMutation({
		mutationFn: (id) => api.delete(`/products/${id}`),
		onSuccess: async () => {
			await queryClient.invalidateQueries({ queryKey: ['products'] });
			toast.success('Product deleted!');
		},
	});
};
