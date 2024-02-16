#include <string>

namespace log_line {
    std::string message(std::string log_message) {
       return log_message.substr(log_message.find(": ") + 2);
    }

    std::string log_level(std::string log_message) {
       return log_message.substr(1, log_message.find(": ") - 2);
    }

    std::string reformat(std::string log_message) {
       return message(log_message) + " (" + log_level(log_message) + ")";
    }
} // namespace log_line
