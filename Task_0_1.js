var a = [1, 2, 3, [4, 5, 6, [7, 8, 9, [0]]]];
var b = [];

function toOneLineArr(a, b) {
	for(let i = 0; i < a.length; i++) 
		typeof(a[i]) == 'object' ? toOneLineArr(a[i], b) : b[b.length] = a[i];
}

toOneLineArr(a, b);
console.log(a);		// [1, 2, 3, [4, 5, 6, [7, 8, 9, [0]]]]
console.log(b);		// [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
