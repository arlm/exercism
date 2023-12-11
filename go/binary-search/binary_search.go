package binarysearch

import (
	"sort"
)

func SearchInts(list []int, key int) int {
	listLen := len(list)

	if listLen == 0 {
		return -1
	}

	sort.Ints(list[0:])
	searchIndex := listLen / 2
	initialSearchIndex := searchIndex
	searchStep := searchIndex
	value := list[searchIndex]

	if value == key {
		return searchIndex
	}

	for value != key && searchIndex >= 0 {
		searchStep /= 2

		if searchStep == 0 {
			searchStep = 1
		}

		if value > key {
			if searchIndex == 0 {
				break
			} else if searchIndex == 1 {
				searchIndex = 0
			} else {
				searchIndex -= searchStep
			}
		} else {
			if searchIndex == (listLen - 1) {
				break
			} else if searchIndex == (listLen - 2) {
				searchIndex = listLen - 1
			} else {
				searchIndex += searchStep
			}
		}

		if searchIndex == initialSearchIndex {
			break
		}

		value = list[searchIndex]

		if value == key {
			return searchIndex
		}
	}

	return -1
}
