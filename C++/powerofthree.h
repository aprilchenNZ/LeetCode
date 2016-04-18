#pragma once
class OONESolution {
public:
	bool isPowerofThree(int n) {
		const int maxintvalue = 2147483647;
		const int maxthreepow = 1162261467;
		return (n > 0 && maxthreepow % n == 0);
	}
};