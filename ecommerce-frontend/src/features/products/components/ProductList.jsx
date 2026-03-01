import React, { useState } from 'react';
import {
	useProducts,
	useCreateProduct,
	useUpdateProduct,
	useDeleteProduct,
} from '../api/productApi';
import Pagination from '../../../components/Pagination.jsx';
import ProductForm from './ProductForm';
import { Edit2, Trash2, Plus } from 'lucide-react';

const ProductList = () => {
	const [isFormOpen, setIsFormOpen] = useState(false);
	const [editingProduct, setEditingProduct] = useState(null);

	const [page, setPage] = useState(1);
	const pageSize = 6;

	const { data, isLoading, isError } = useProducts(page, pageSize);
	const createMutation = useCreateProduct();
	const updateMutation = useUpdateProduct();
	const deleteMutation = useDeleteProduct();

	const handleSave = (formData) => {
		if (editingProduct) {
			updateMutation.mutate(
				{ id: editingProduct.id, data: formData },
				{
					onSuccess: () => {
						setIsFormOpen(false);
						setEditingProduct(null);
					},
				},
			);
		} else {
			createMutation.mutate(formData, {
				onSuccess: () => setIsFormOpen(false),
			});
		}
	};

	const handleDelete = (id) => {
		if (window.confirm('Are you sure you want to delete this product?')) {
			deleteMutation.mutate(id);
		}
	};

	if (isLoading)
		return <div className="text-center py-10">Loading products catalog...</div>;
	if (isError || !data) return null;

	return (
		<div className="space-y-6">
			<div className="flex justify-between items-center">
				<h1 className="text-2xl font-bold text-gray-900">Manage Products</h1>
				<button
					onClick={() => {
						setEditingProduct(null);
						setIsFormOpen(true);
					}}
					className="flex items-center gap-2 bg-indigo-600 text-white px-4 py-2 rounded-lg hover:bg-indigo-700">
					<Plus size={18} /> Add Product
				</button>
			</div>

			{/*<div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                {data?.items.map((product) => (
                    <div key={product.id}
                         className="bg-white rounded-xl shadow-sm border border-gray-100 overflow-hidden hover:shadow-md transition-shadow">
                        <div className="p-5">
                            <h3 className="font-semibold text-lg text-gray-900">{product.name}</h3>
                            <p className="text-gray-500 text-sm mt-1 line-clamp-2">{product.description}</p>

                            <div className="mt-4 flex items-center justify-between">
                                <span className="text-2xl font-bold text-indigo-600">${product.price}</span>
                                <span className={`text-xs font-medium px-2 py-1 rounded ${
                                    product.quantity > 0 ? 'bg-green-100 text-green-700' : 'bg-red-100 text-red-700'
                                }`}>
                  {product.quantity > 0 ? `${product.quantity} in stock` : 'Out of Stock'}
                </span>
                            </div>
                        </div>
                    </div>
                ))}
            </div>*/}

			<div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
				{data?.items.map((product) => (
					<div
						key={product.id}
						className="bg-white border p-5 rounded-xl shadow-sm group">
						<div className="flex justify-between items-start">
							<div>
								<h3 className="font-bold">{product.name}</h3>
								<p className="text-gray-500 text-sm mt-1 line-clamp-2">
									{product.description}
								</p>
							</div>
							<div className="flex gap-2 ">
								<button
									onClick={() => {
										setEditingProduct(product);
										setIsFormOpen(true);
									}}
									className="p-2 text-gray-400 hover:text-blue-600 bg-gray-50 rounded">
									<Edit2 size={16} />
								</button>
								<button
									onClick={() => handleDelete(product.id)}
									className="p-2 text-gray-400 hover:text-red-600 bg-gray-50 rounded">
									<Trash2 size={16} />
								</button>
							</div>
						</div>
						<div className="mt-4 flex items-center justify-between">
							<span className="text-2xl font-bold text-indigo-600">
								${product.price}
							</span>
							<span
								className={`text-xs font-medium px-2 py-1 rounded ${
									product.quantity > 0
										? 'bg-green-100 text-green-700'
										: 'bg-red-100 text-red-700'
								}`}>
								{product.quantity > 0
									? `${product.quantity} in stock`
									: 'Out of Stock'}
							</span>
						</div>
					</div>
				))}
			</div>

			<Pagination
				currentPage={data.pageNumber}
				totalPages={data.totalPages}
				hasNextPage={data.hasNextPage}
				hasPreviousPage={data.hasPreviousPage}
				onPageChange={(newPage) => setPage(newPage)}
			/>
			{isFormOpen && (
				<ProductForm
					product={editingProduct}
					isPending={createMutation.isPending || updateMutation.isPending}
					onClose={() => setIsFormOpen(false)}
					onSubmit={handleSave}
				/>
			)}
		</div>
	);
};

export default ProductList;
