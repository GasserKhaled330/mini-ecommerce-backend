import { useState, useEffect } from 'react';
import { X } from 'lucide-react';

const ProductForm = ({ product, onClose, onSubmit, isPending }) => {
	const [formData, setFormData] = useState({
		name: '',
		description: '',
		price: 0,
		quantity: 0,
	});
	const [errors, setErrors] = useState({});

	useEffect(() => {
		if (product) setFormData(product);
	}, [product]);

	const validate = () => {
		const newErrors = {};
		if (!formData.name.trim()) newErrors.name = 'Name is required';
		if (!formData.description.trim())
			newErrors.description = 'Description is required';
		if (formData.description.length > 500)
			newErrors.description = 'Description cannot exceed 500 characters';
		if (formData.price <= 0) newErrors.price = 'Price must be greater than 0';
		if (formData.quantity < 0) newErrors.quantity = 'Stock cannot be negative';

		setErrors(newErrors);
		return Object.keys(newErrors).length === 0;
	};

	const handleSubmit = (e) => {
		e.preventDefault();
		if (validate()) {
			onSubmit(formData);
		}
	};

	return (
		<div className="fixed inset-0 bg-black/50 flex items-center justify-center z-100 p-4">
			<div className="bg-white rounded-2xl w-full max-w-md shadow-2xl">
				<div className="flex justify-between items-center p-6 border-b">
					<h2 className="text-xl font-bold">
						{product ? 'Edit Product' : 'New Product'}
					</h2>
					<button
						onClick={onClose}
						className="text-gray-400 hover:text-gray-600">
						<X />
					</button>
				</div>

				<form onSubmit={handleSubmit} className="p-6 space-y-4">
					<div>
						<label className="block text-sm font-medium mb-1">
							Product Name
						</label>
						<input
							required
							className="w-full p-2 border rounded-lg outline-none focus:ring-2 focus:ring-indigo-500"
							value={formData.name}
							onChange={(e) =>
								setFormData({ ...formData, name: e.target.value })
							}
						/>
						{errors.name && (
							<p className="text-red-500 text-xs mt-1">{errors.name}</p>
						)}
					</div>
					<div>
						<label className="block text-sm font-medium mb-1">
							Description
						</label>
						<textarea
							className="w-full resize-none p-2 border rounded-lg outline-none focus:ring-2 focus:ring-indigo-500"
							value={formData.description}
							onChange={(e) =>
								setFormData({ ...formData, description: e.target.value })
							}
							required
						/>
						{errors.description && (
							<p className="text-red-500 text-xs mt-1">{errors.description}</p>
						)}
					</div>
					<div className="grid grid-cols-2 gap-4">
						<div>
							<label className="block text-sm font-medium mb-1">
								Price ($)
							</label>
							<input
								type="number"
								step="1"
								min={1}
								required
								className="w-full p-2 border rounded-lg outline-none focus:ring-2 focus:ring-indigo-500"
								value={formData.price}
								onChange={(e) =>
									setFormData({
										...formData,
										price: parseFloat(e.target.value),
									})
								}
							/>
							{errors.price && (
								<p className="text-red-500 text-xs mt-1">{errors.price}</p>
							)}
						</div>
						<div>
							<label className="block text-sm font-medium mb-1">
								Stock Quantity
							</label>
							<input
								type="number"
								required
								min={0}
								className="w-full p-2 border rounded-lg outline-none focus:ring-2 focus:ring-indigo-500"
								value={formData.quantity}
								onChange={(e) =>
									setFormData({
										...formData,
										quantity: parseInt(e.target.value),
									})
								}
							/>
							{errors.quantity && (
								<p className="text-red-500 text-xs mt-1">{errors.quantity}</p>
							)}
						</div>
					</div>

					<div className="pt-4 flex gap-3">
						<button
							type="button"
							onClick={onClose}
							className="flex-1 py-2 border rounded-lg font-medium hover:bg-gray-50">
							Cancel
						</button>
						<button
							type="submit"
							disabled={isPending}
							className="flex-1 py-2 bg-indigo-600 text-white rounded-lg font-medium hover:bg-indigo-700 disabled:bg-indigo-300">
							{isPending ? 'Saving...' : 'Save Product'}
						</button>
					</div>
				</form>
			</div>
		</div>
	);
};

export default ProductForm;
